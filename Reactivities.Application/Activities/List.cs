using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Reactivities.Application.Core;
using Reactivities.Domain;
using Reactivities.Persistence;

namespace Reactivities.Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<ActivityDto>>> { }
        public class Handler : IRequestHandler<Query, Result<List<ActivityDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<ActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await _context.Activities
                    .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<ActivityDto>>.Success(activities); 
            }
        }
    }
}

/*
ProjectTo metodu, AutoMapper kütüphanesinin bir parçasıdır ve Entity Framework ile birlikte kullanıldığında oldukça yararlıdır. 
Bu metot, veritabanından veri çekerken, verileri doğrudan hedef tipine dönüştürmek için kullanılır. 
Bu, veritabanından çekilen verilerin bellekte işlenmeden önce hedef tipine dönüştürülmesini sağlar ve performansı iyileştirebilir.

ProjectTo Metodunun Kullanımı ve Avantajları
    ProjectTo metodu, veritabanı sorgusunu (örneğin, LINQ sorgusunu) alır ve bu sorguyu AutoMapper konfigürasyonuna göre hedef tipin (bu örnekte ActivityDto) bir sorgusuna dönüştürür.
    Bu işlem, veritabanından sadece gerekli verilerin çekilmesini sağlar, çünkü AutoMapper dönüşüm kurallarına göre hangi verilerin gerekli olduğunu belirler.
    Bu yaklaşım, veritabanı yükünü azaltır ve uygulamanın performansını artırır, çünkü gereksiz veri çekme ve dönüştürme işlemleri yapılmaz.

Sonuç olarak, ProjectTo metodu, veritabanından veri çekerken otomatik dönüşüm yaparak, daha temiz ve performans odaklı bir kod yazmanıza olanak tanır. 
Bu, özellikle büyük veri setleri ve karmaşık dönüşüm işlemleri söz konusu olduğunda önemlidir.

---> SQL sorgusunu sadece gerekli verileri çekecek şekilde optimize eder. <---
*/