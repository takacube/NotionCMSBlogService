using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures;
public record NotionSettings(
    string PageUrl,
    string BlockVhildUrl,
    string BlockUrl, 
    string Authorization,
    string NotionVersion)
{
    public NotionSettings() : this(
        PageUrl: string.Empty,
        BlockVhildUrl: string.Empty,
        BlockUrl: string.Empty,
        Authorization: string.Empty,
        NotionVersion: string.Empty)
    { }
}
