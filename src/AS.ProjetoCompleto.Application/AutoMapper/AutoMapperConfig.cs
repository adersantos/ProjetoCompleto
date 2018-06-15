using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS.ProjetoCompleto.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        //chamado sem precisar criar instancia da classe
        public static void RegisterMappings()
        {
            Mapper.Initialize(i =>
            {
                i.AddProfile<DomainToViewModelMappingProfile>();
                //i.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
