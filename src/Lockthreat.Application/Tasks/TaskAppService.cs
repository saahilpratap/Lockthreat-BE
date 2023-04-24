using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Lockthreat.AddTasks;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Common;
using Lockthreat.Countries;
using Lockthreat.Fileupload;
using Lockthreat.Meetings;
using Lockthreat.Projects;
using Lockthreat.ProjectsInfo.Dto;
using Lockthreat.Tasks.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Tasks
{
    public class TaskAppService : LockthreatAppServiceBase, ITaskAppService
    {
        private readonly IRepository<AddTask, long> _taskRepository;
        private readonly IRepository<TaskAssociatedProject, long> _taskAssociatedRepository;
        private readonly IRepository<TaskAttachment, long> _taskAttachmentRepository;
        private readonly IRepository<TaskNotification, long> _taskNotificationRepository;
        private readonly IRepository<TaskRelatedMember, long> _taskRelatedRepository;
        private readonly IRepository<MeetingTask, long> _meetingTaskRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<Project, long> _projectsDetailsRepository;
        private readonly IRepository<Meeting, long> _meetingRepository;
        private readonly IFileUploadAppService _fileUploadAppService;

        public TaskAppService(IRepository<AddTask, long> taskRepository, 
            IRepository<TaskAssociatedProject, long> taskAssociatedRepository, 
            IRepository<TaskAttachment, long> taskAttachmentRepository ,
            IRepository<TaskNotification, long> taskNotificationRepository,
            IRepository<TaskRelatedMember, long> taskRelatedRepository,
            IRepository<MeetingTask, long> meetingTaskRepository, 
            ICodeGeneratorCommonAppservice codegeneratorRepository,
            IRepository<Employees.Employee, long> employessRepository,
            ICountriesAppservice countriesAppservice,
            IRepository<Project, long> projectsDetailsRepository,
            IRepository<Meeting, long> meetingRepository, IFileUploadAppService fileUploadAppService)
        {
            _taskRepository = taskRepository;
            _taskAssociatedRepository = taskAssociatedRepository;
            _taskAttachmentRepository = taskAttachmentRepository;
            _taskNotificationRepository = taskNotificationRepository;
            _taskRelatedRepository = taskRelatedRepository;
            _meetingTaskRepository = meetingTaskRepository;
            _codegeneratorRepository = codegeneratorRepository;
            _employessRepository = employessRepository;
            _countriesAppservice = countriesAppservice;
            _projectsDetailsRepository = projectsDetailsRepository;
            _meetingRepository = meetingRepository;
            _fileUploadAppService = fileUploadAppService;
        }

        public async Task<TaskinfoDto> GetTaskinfo (long? TaskId )
        {
            try
            {
                TaskinfoDto Tasks  = new TaskinfoDto();
                AddTask TaskInfoById = new AddTask();
                if (TaskId > 0)
                {
                    TaskInfoById  = await _taskRepository.GetAll().Include(p => p.AssignedUser).Include(p => p.TaskType).Include(x=>x.AssignedTo).Include(p=>p.LinkedTo).FirstOrDefaultAsync(p => p.Id == TaskId);
                }

                if (TaskInfoById.Id > 0)
                {
                    Tasks = ObjectMapper.Map<TaskinfoDto>(TaskInfoById);
                    Tasks.SelectedAssociatedProjects = ObjectMapper.Map<List<TaskAssociatedProjectDto>>(await _taskAssociatedRepository.GetAll().Where(p => p.AddTaskId == TaskId).ToListAsync());
                    Tasks.SelectedMeetingTasks = ObjectMapper.Map<List<MeetingTaskDto>>(await _meetingTaskRepository.GetAll().Where(p => p.AddTaskId == TaskId).ToListAsync());
                    Tasks.SelectedRelatedMembers = ObjectMapper.Map<List<TaskRelatedMemberDto>>(await _taskRelatedRepository.GetAll().Where(p => p.AddTaskId == TaskId).ToListAsync());
                    Tasks.SelectedTaskNotifications = ObjectMapper.Map<List<TaskNotificationDto>>(await _taskNotificationRepository.GetAll().Where(p => p.AddTaskId == TaskId).ToListAsync());
                    Tasks.SelectedTaskTaskAttachments = ObjectMapper.Map<List<TaskAttachmentDto>>(await _taskAttachmentRepository.GetAll().Where(p => p.AddTaskId == TaskId).ToListAsync());
                }  
                
                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                Tasks.AssignedToList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                Tasks.AssignedUserList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                Tasks.RequestedList= ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                Tasks.ProjectList= ObjectMapper.Map<List<ProjectListsDto>>(await _projectsDetailsRepository.GetAll().ToListAsync());
                Tasks.MeetingList= ObjectMapper.Map<List<MeetingsDto>>(await _meetingRepository.GetAll().ToListAsync());
                Tasks.RiskLevels= await _countriesAppservice.GetRiskLevel();
                Tasks.Statuses= await _countriesAppservice.GetKeyRiskStatus();
                Tasks.LinkedList= await _countriesAppservice.GetTaskLinked();
                Tasks.TaskTypes = await _countriesAppservice.GetTaskType();
                return Tasks;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PagedResultDto<TaskListDto>> GetAllTasksList(GetTasksInput input)
        {
            var query = _taskRepository.GetAllIncluding().Include(x=>x.AssignedUser).Include(x=>x.AssignedTo).Include(x=>x.TaskType);
            var tasksCount = await query.CountAsync();
            var tasksItems = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var taskListDtos = ObjectMapper.Map<List<TaskListDto>>(tasksItems);
            return new PagedResultDto<TaskListDto>(
               tasksCount,
               taskListDtos.ToList()
               );
        }

        public async Task CreateorEditTask (TaskinfoDto task )   
        {
            List<string> fileUrls = new List<string>();
            try
            {
                if (string.IsNullOrEmpty(task.TaskId))
                {
                    task.TaskId = _codegeneratorRepository.GetNextId(LockthreatConsts.TASk, "TAS");
                    
                }

                task.TenantId = AbpSession.TenantId;
                TaskinfoDto result = new TaskinfoDto();
                var res = ObjectMapper.Map<AddTask>(task);

                fileUrls = await _fileUploadAppService.UploadFiles(task.UploadFiles);

                fileUrls.ForEach(x =>
                {
                    TaskAttachment dt = new TaskAttachment();
                    dt.AddTaskId = 0;
                    dt.Id = 0;
                    dt.Document = x;
                    res.SelectedTaskTaskAttachments.Add(dt);
                });

                if (task.Id > 0)
                {
                    if (task.RemovedAssociatedProjects != null)
                    {
                        foreach (var ex  in task.RemovedAssociatedProjects)
                        {
                            bool exist = _taskAssociatedRepository.GetAll().Any(t => t.Id == ex);
                            if (exist)
                            {
                                await RemovedAssociatedProjects(ex);
                            }
                        }
                    }

                    if (task.RemovedMeetingTasks != null)
                    {
                        foreach (var ex in task.RemovedMeetingTasks)
                        {
                            bool exist = _meetingTaskRepository.GetAll().Any(t => t.Id == ex);
                            if (exist)
                            {
                               await RemovedMeetingTasks(ex);
                            }
                        }
                    }

                    if (task.RemovedNotifications != null)
                    {
                        foreach (var ex in task.RemovedNotifications)
                        {
                            bool exist = _taskNotificationRepository.GetAll().Any(t => t.Id == ex);
                            if (exist)
                            {
                                await RemovedNotifications(ex);
                            }
                        }
                    }

                    if (task.RemovedRelatedMembers != null)
                    {
                        foreach (var ex in task.RemovedRelatedMembers)
                        {
                            bool exist = _taskRelatedRepository.GetAll().Any(t => t.Id == ex);
                            if (exist)
                            {
                                await RemovedRelatedMembers(ex);
                            }
                        }
                    }

                    if (task.RemovedTaskTaskAttachments != null)
                    {
                        foreach (var ex in task.RemovedTaskTaskAttachments)
                        {
                            bool exist = _taskAttachmentRepository.GetAll().Any(t => t.Id == ex);
                            if (exist)
                            {
                                await RemovedTaskTaskAttachments(ex);
                            }
                        }
                    }                   
                }

                await _taskRepository.InsertOrUpdateAsync(ObjectMapper.Map<AddTask>(res));
                if (task.Id == 0)
                {
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.TASk, "TAS");
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemovedAssociatedProjects(long id)
        {
            try
            {
                var authDoc = await _taskAssociatedRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _taskAssociatedRepository.DeleteAsync(authDoc);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemovedMeetingTasks (long id)
        {
            try
            {
                var country = await _meetingTaskRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _meetingTaskRepository.DeleteAsync(country);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemovedNotifications(long id)
        {
            try
            {
                var member = await _taskNotificationRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _taskNotificationRepository.DeleteAsync(member);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemovedRelatedMembers (long id)
        {
            try
            {
                var member = await _taskRelatedRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _taskRelatedRepository.DeleteAsync(member);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemovedTaskTaskAttachments (long id)
        {
            try
            {
                var member = await _taskAttachmentRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _taskAttachmentRepository.DeleteAsync(member);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveTask (long taskId )
        {
            try
            {
                var task  = await _taskRepository.GetAll().Where(p => p.Id == taskId).Include(p => p.SelectedAssociatedProjects)
                    .Include(p => p.SelectedMeetingTasks).Include(p => p.SelectedRelatedMembers).Include(p => p.SelectedTaskNotifications)
                    .Include(p => p.SelectedTaskTaskAttachments).FirstOrDefaultAsync();

                if (task.SelectedAssociatedProjects.Count > 0)
                {
                    foreach (var item in task.SelectedAssociatedProjects)
                    {
                        await RemovedAssociatedProjects(item.Id);
                    }
                }

                if (task.SelectedMeetingTasks.Count > 0)
                {
                    foreach (var item in task.SelectedMeetingTasks)
                    {
                        await RemovedMeetingTasks(item.Id);
                    }
                }

                if (task.SelectedRelatedMembers.Count > 0)
                {
                    foreach (var item in task.SelectedRelatedMembers)
                    {
                        await RemovedRelatedMembers(item.Id);
                    }
                }

                if (task.SelectedTaskNotifications.Count > 0)
                {
                    foreach (var item in task.SelectedTaskNotifications)
                    {
                        await RemovedNotifications(item.Id);
                    }
                }

                if (task.SelectedTaskTaskAttachments.Count > 0)
                {
                    foreach (var item in task.SelectedTaskTaskAttachments)
                    {
                        await RemovedTaskTaskAttachments(item.Id);
                    }
                }

              

                await _taskRepository.DeleteAsync(task);

            }
            catch (Exception)
            {

                throw;
            }
        }

      
    }
}
