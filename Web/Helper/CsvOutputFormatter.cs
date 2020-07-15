﻿using Web.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Web.Helper
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(VMCoaMap).IsAssignableFrom(type) || typeof(IEnumerable<VMCoaMap>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<VMCoaMap>)
            {
                foreach (var coamap in (IEnumerable<VMCoaMap>)context.Object)
                {
                    FormatCsv(buffer, coamap);
                }
            }
            else
            {
                FormatCsv(buffer, (VMCoaMap)context.Object);
            }

            await response.WriteAsync(buffer.ToString());
        }

        private static void FormatCsv(StringBuilder buffer, VMCoaMap coamap)
        {
            buffer.AppendLine($"{coamap.contype},\"{coamap.constatus},\"{coamap.conlength},\"{coamap.ACT},\"{coamap.ACT_DESC},\"{coamap.DG},\"{coamap.SERVICE},\"{coamap.IS_INT},\"{coamap.COA_PROD},\"{coamap.COA_ARUS}\"");
        }

    }
}
