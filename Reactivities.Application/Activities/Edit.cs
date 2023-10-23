﻿using AutoMapper;
using FluentValidation;
using MediatR;
using Reactivities.Application.Core;
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
        public class Command : IRequest<Result<Unit>>
        {
            public Activity Activitiy { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator()
                {
                    RuleFor(x => x.Activitiy).SetValidator(new ActivityValidator());
                }
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activitiy.Id);

                if(activity == null) return null;

                // TODO: Bu kısımı düzeltmek gerekiyor.
                //<Form.Input type='date' placeholder='Date' value={activity.date} name='date' onChange={handleInputChange}/>
                request.Activitiy.Date = DateTime.UtcNow.AddDays(10); // Yukarıdaki satırdan istenilen formatta veri gelmiyor o nedenle geçiçi çözüm olarak bu satır eklendi.
                //Cannot write DateTime with Kind = Unspecified to PostgreSQL type 'timestamp with time zone', only UTC is supported.

                _mapper.Map(request.Activitiy, activity);

                var result = await _context.SaveChangesAsync() > 0;

                if(!result) return Result<Unit>.Failure("Failed to update activity");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}