using Dapper;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.Mapper
{
    public class PascalCaseMapper<T>
    {
        public static void SetTypeMap()
        {
            var type = typeof(T);
            SqlMapper.SetTypeMap(type, new CustomPropertyTypeMap(
                type,
                (t, columnName) =>
                {
                    return t.GetProperty(columnName.ToPascalCase());
                }));
        }


    }
        public static class StringExtensions
    {
        public static string ToPascalCase(this string columnName)
        {
            if (string.IsNullOrEmpty(columnName))
                return columnName;

            // Split the column name by underscores and capitalize each part
            var parts = columnName.Split('_', StringSplitOptions.RemoveEmptyEntries);
            var pascalCaseName = string.Join("", parts.Select(p => char.ToUpper(p[0]) + p.Substring(1).ToLower()));

            return pascalCaseName;
        }
    }

}
