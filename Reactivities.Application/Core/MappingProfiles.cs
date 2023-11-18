using AutoMapper;
using Reactivities.Application.Activities;
using Reactivities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactivities.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();

            
            CreateMap<Activity, ActivityDto>()
                .ForMember(d => d.HostUsername, 
                    o => o.MapFrom(s => s.Attendees
                    .FirstOrDefault(x => x.IsHost).AppUser.UserName));
            /* ActivityDto'nun HostUsername alanını doldururken, 
            Activity'nin Attendees koleksiyonunu kontrol eder.
            Attendees içinde IsHost özelliği true olan ilk katılımcıyı bulur.
            Bu katılımcının kullanıcı adını (UserName) ActivityDto'nun HostUsername alanına kopyalar. */

            CreateMap<ActivityAttendee, Profiles.Profile>()
                .ForMember(d => d.DisplayName, 
                    o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.Username, 
                    o => o.MapFrom(s => s.AppUser.UserName))
                .ForMember(d => d.Bio, 
                    o => o.MapFrom(s => s.AppUser.Bio));
        }
    }
}

/*
AutoMapper'da MapFrom metodu, bir özelliğin değerinin nereden alınacağını belirtmek için kullanılır
Yani, bir nesneden başka bir nesneye veri aktarırken, belirli bir özelliğin değerinin kaynağını tanımlarsınız.

    MapFrom metodu, genellikle ForMember metodu ile birlikte kullanılır.
    ForMember metodu, hedef nesnenin hangi özelliğinin doldurulacağını belirtir.
    MapFrom ise bu özelliğin değerinin kaynak nesnenin hangi özelliğinden veya ifadesinden alınacağını tanımlar.

Özetle, MapFrom metodu, hedef nesnenin bir özelliğinin değerinin kaynak nesneden nasıl alınacağını tanımlar. 
Bu, veri aktarımı sırasında özelleştirilmiş dönüşümler yapmanızı sağlar, böylece daha karmaşık veri yapılarını kolayca yönetebilirsiniz.
*/