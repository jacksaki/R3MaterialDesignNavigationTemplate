using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace R3JsonExtensions;

public interface IHasJsonObject
{
    public JsonObject? JsonObject { get; set; }
}
