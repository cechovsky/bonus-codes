using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BonusCodes.Services
{
    public interface IBonusCodesService
    {
        bool IsValid(string code);
        bool AlreadyExists(string code);
        void Add(string code);
    }

    public class BonusCodesService : IBonusCodesService
    {
        private readonly ICollection<string> storedCodes;

        public BonusCodesService()
        {
            storedCodes = new List<string>();
        }

        public bool IsValid(string code)
        {
            var regex = new Regex(@"[A-Z]{3}-[A-Z]{3}");
            var match = regex.Match(code);
            return match.Success;
        }

        public bool AlreadyExists(string code)
        {
            return storedCodes.Contains(code);
        }

        public void Add(string code)
        {
            storedCodes.Add(code);
        }
    }
}