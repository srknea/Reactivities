using MediatR;
using Reactivities.Domain;
using Reactivities.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactivities.Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activitiy { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activitiy.Id);

                activity.Title = request.Activitiy.Title ?? activity.Title; // if request.Activitiy.Title is null, then activity.Title will be activity.Title
                activity.Description = request.Activitiy.Description ?? activity.Description;

                await _context.SaveChangesAsync();
            }
        }
    }
}

// Şu an sadece activity.Title ve activity.Description için güncelleme yapılabiliyor...