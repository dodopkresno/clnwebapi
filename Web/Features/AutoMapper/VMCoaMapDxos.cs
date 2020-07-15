using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entity;
using Web.ViewModel;
using Web.Interface;

namespace Web.Features.AutoMapper
{
    public class VMCoaMapDxos : ICoaMapProfile
    {
        private readonly IMapper _mapper;
        public VMCoaMapDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MapCoa, VMCoaMap>()
                    .ForMember(dst => dst.contype, opt => opt.MapFrom(src => src.CTYPE))
                    .ForMember(dst => dst.constatus, opt => opt.MapFrom(src => src.CSTS))
                    .ForMember(dst => dst.conlength, opt => opt.MapFrom(src => src.CLENGTH))
                    .ForMember(dst => dst.ACT, opt => opt.MapFrom(src => src.ACT))
                    .ForMember(dst => dst.ACT_DESC, opt => opt.MapFrom(src => src.ACT_DESC))
                    .ForMember(dst => dst.DG, opt => opt.MapFrom(src => src.DG))
                    .ForMember(dst => dst.SERVICE, opt => opt.MapFrom(src => src.SERVICE))
                    .ForMember(dst => dst.IS_I, opt => opt.MapFrom(src => src.IS_I))
                    .ForMember(dst => dst.COA_ARUS, opt => opt.MapFrom(src => src.COA_ARUS))
                    .ForMember(dst => dst.COA_PROD, opt => opt.MapFrom(src => src.COA_PROD));
            });

            _mapper = config.CreateMapper();
        }
        public VMCoaMap MapVMCoaMap(MapCoa mapCoa)
        {   
            return _mapper.Map<MapCoa, VMCoaMap>(mapCoa);
        }
    }
}
