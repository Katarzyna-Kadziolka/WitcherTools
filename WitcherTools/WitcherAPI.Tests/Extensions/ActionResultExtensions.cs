using Microsoft.AspNetCore.Mvc;

namespace WitcherAPI.Tests.Extensions {
    public static class ActionResultExtensions {
        public static T GetValue<T>(this ActionResult<T> result) {
            if (result.Result != null)
                return(T) ((ObjectResult) result.Result).Value;
            return result.Value;
        }
    }
}