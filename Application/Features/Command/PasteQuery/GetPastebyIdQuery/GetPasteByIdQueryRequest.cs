using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.PasteQuery.GetPastebyIdQuery
{
    public class GetPasteByIdQueryRequest:IRequest<GetPasteByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
