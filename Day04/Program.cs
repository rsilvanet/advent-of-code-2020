using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day04
{
    public class Program
    {
        public static void Main(string[] _)
        {
            Console.WriteLine($"Part 1: {Part1()}");
            Console.WriteLine($"Part 2: {Part2()}");
            Console.ReadLine();
        }

        public static long Part1()
        {
            return GetEntries().Where(x => x.HasAllRequiredFields()).Count();
        }

        public static long Part2()
        {
            return GetEntries().Where(x => x.AllFieldsAreValid()).Count();
        }

        public static IEnumerable<EntryDTO> GetEntries()
        {
            var current = new EntryDTO();
            var entries = new List<EntryDTO>() { current };

            foreach (var line in Input.Lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    current = new EntryDTO();
                    entries.Add(current);
                    continue;
                }

                current.ReadLine(line);
            }

            return entries;
        }

        public class EntryDTO
        {
            private const string Birth_Year = "byr";
            private const string Issue_Year = "iyr";
            private const string Expiration_Year = "eyr";
            private const string Height = "hgt";
            private const string Hair_Color = "hcl";
            private const string Eye_Color = "ecl";
            private const string Passport_ID = "pid";

            private readonly static string[] requiredFields = new string[]
            {
                Birth_Year, Issue_Year, Expiration_Year, Height, Hair_Color, Eye_Color, Passport_ID
            };

            private readonly static string[] possibleEyeColors = new string[]
            {
                "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
            };

            private readonly IDictionary<string, string> keyValues = new Dictionary<string, string>();

            public void ReadLine(string line)
            {
                foreach (var field in line.Split(" "))
                {
                    var fieldParts = field.Split(":");
                    var key = fieldParts.First();
                    var value = fieldParts.Last();

                    keyValues.Add(key, value);
                }
            }

            public bool HasAllRequiredFields()
            {
                foreach (var requiredField in requiredFields)
                {
                    if (!keyValues.ContainsKey(requiredField))
                    {
                        return false;
                    }
                }

                return true;
            }

            public bool AllFieldsAreValid()
            {
                return HasAllRequiredFields()
                    && HasValidBirthdayYear()
                    && HasValidIssueYear()
                    && HasValidExpirationYear()
                    && HasValidHeigth()
                    && HasValidHairColor()
                    && HasValidEyeColor()
                    && HasValidPassportID();
            }

            private bool HasValidBirthdayYear()
            {
                var birthYear = int.Parse(keyValues[Birth_Year]);

                if (birthYear < 1920 || birthYear > 2002)
                {
                    return false;
                }

                return true;
            }

            private bool HasValidIssueYear()
            {
                var issueYear = int.Parse(keyValues[Issue_Year]);

                if (issueYear < 2010 || issueYear > 2020)
                {
                    return false;
                }

                return true;
            }

            private bool HasValidExpirationYear()
            {
                var expirationYear = int.Parse(keyValues[Expiration_Year]);

                if (expirationYear < 2020 || expirationYear > 2030)
                {
                    return false;
                }

                return true;
            }

            private bool HasValidHeigth()
            {
                var height = keyValues[Height];

                if (height.EndsWith("cm"))
                {
                    var heightValue = int.Parse(height.Replace("cm", ""));

                    if (heightValue < 150 || heightValue > 193)
                    {
                        return false;
                    }
                }
                else if (height.EndsWith("in"))
                {
                    var heightValue = int.Parse(height.Replace("in", ""));

                    if (heightValue < 59 || heightValue > 76)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                return true;
            }

            private bool HasValidHairColor()
            {
                var hairColor = keyValues[Hair_Color];

                if (!Regex.IsMatch(hairColor, "^#[a-zA-Z0-9]{6}$"))
                {
                    return false;
                }

                return true;
            }

            private bool HasValidEyeColor()
            {
                var eyeColor = keyValues[Eye_Color];

                if (!possibleEyeColors.Contains(eyeColor))
                {
                    return false;
                }

                return true;
            }

            private bool HasValidPassportID()
            {
                var passportID = keyValues[Passport_ID];

                if (!Regex.IsMatch(passportID, "^[0-9]{9}$"))
                {
                    return false;
                }

                return true;
            }
        }
    }
}
