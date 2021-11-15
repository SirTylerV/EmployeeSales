using EmployeeSales.Enums;
using System.Collections.Generic;

namespace EmployeeSales.Services.Helpers
{
    public static class StoredProcedures
    {
        // Will add all SP SQL to this list with parameters to keep encapsulated.
        private static Dictionary<StoredProcedureEnum, string> _spScriptMatch = new Dictionary<StoredProcedureEnum, string>() {
            { StoredProcedureEnum.GetStoreListData, "EXEC usp_GetStoreListData" }
        };

        // When a SP needs to be run, the Repository will pass in the enum of the procedure they want
        public static string GetProcedure(StoredProcedureEnum sp)
        {
            return _spScriptMatch.GetValueOrDefault(sp);
        }
    }
}
