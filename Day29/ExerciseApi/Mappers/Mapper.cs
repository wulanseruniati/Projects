using AutoMapper;

public class Mapper : Profile
{
    public Mapper()
    {
        //source,destination
        CreateMap<ComponentDTO,Component>().ReverseMap(); //untuk bolak balik
        CreateMap<ItemDTO,Item>().ReverseMap();
    }
}