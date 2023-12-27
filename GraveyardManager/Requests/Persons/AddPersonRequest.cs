﻿using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Requests.Persons
{
    public record AddPersonRequest(int GraveId, Person Person) : IRequest<Grave> { }

    public class AddPersonRequestHandler : IRequestHandler<AddPersonRequest, Grave>
    {
        GraveDbContext _context;

        public AddPersonRequestHandler(GraveDbContext context)
        {
            _context = context;
        }

        public Task<Grave> Handle(AddPersonRequest request, CancellationToken cancellationToken)
        {
            Grave grave = _context.Graves
                .Include(x => x.Persons)
                .ToList()
                .Find(x=> x.Id == request.GraveId) ?? throw new NotFoundException("Grave not found");

            grave.Persons.Add(request.Person);

            _context.SaveChanges();

            return Task.FromResult(grave);
        }
    }
}