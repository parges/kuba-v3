using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using kubaapi.Models;
using rl_contract.Models;

namespace kubaapi.Mapper.Profiles
{

    public class TestungProfile : Profile
    {
        public TestungProfile()
        {
            CreateMap<Testung, Testung>();
        }
    }

    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<TestungQuestion, TestungQuestion>();
        }
    }
}
