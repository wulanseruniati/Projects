using AutoMapper;

public class Mapper : Profile
{
    public Mapper()
    {
        //source,destination
        CreateMap<CategoryDTO,Category>().ReverseMap(); //untuk bolak balik
        //untuk collections
    }
}