using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Commands;
using CleanArchitecture.Domain.Core.Bus;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMediatorHandler bus, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _bus = bus;
            _mapper = mapper;
        }

        public void Create(CourseViewModel course)
        {
            _bus.SendCommand(_mapper.Map<CreateCourseCommand>(course));
        }

        public IEnumerable<CourseViewModel> GetCourses()
        {
            return _courseRepository.GetCourses().ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider);
        }
    }
}
