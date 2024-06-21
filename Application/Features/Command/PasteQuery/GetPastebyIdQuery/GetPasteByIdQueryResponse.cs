using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.PasteQuery.GetPastebyIdQuery
{
    public class GetPasteByIdQueryResponse
    {
        
    }

    public class GetPasteByIdQueryResponseModel: GetPasteByIdQueryResponse
    {
        public Paste Model { get; set; }
    }
    public class GetPasteByIdQueryResponseLockMessage: GetPasteByIdQueryResponse
    {
        public string Message { get; set; }
    }
}
