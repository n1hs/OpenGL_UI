using Newtonsoft.Json;
using System;

public static class ObjectCopier
{
    public static T Clone<T>(this T source)
    {
        if (Object.ReferenceEquals(source, null))
        {
            return default(T);
        }

        var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };

        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
    }
}
