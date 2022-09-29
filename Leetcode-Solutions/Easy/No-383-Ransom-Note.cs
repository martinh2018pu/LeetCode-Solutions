namespace Leetcode_Solutions.Easy
{
    using System.Collections;
    using System.Collections.Generic;

    class No_383_Ransom_Note
    {
        // TODO: Create test case and write to console methods. 
        
        public static bool CanConstruct2(string ransomNote, string magazine)
        {
            Hashtable ht = new Hashtable();

            foreach (var ltr in magazine.ToCharArray())
            {
                if (ht.ContainsKey(ltr))
                    ht[ltr] = (int)ht[ltr] + 1;
                else
                    ht.Add(ltr, 1);
            }

            foreach (var noteLtr in ransomNote.ToCharArray())
            {
                if (ht.ContainsKey(noteLtr))
                {
                    if ((int)ht[noteLtr] == 1)
                        ht.Remove(noteLtr);
                    else
                        ht[noteLtr] = (int)ht[noteLtr] - 1;
                }
                else
                    return false;
            }

            return true;
        }

        public static bool CanConstruct(string ransomNote, string magazine)
        {
            var dict = new Dictionary<char,int>();

            foreach (var ltr in magazine.ToCharArray())
            {
                if (dict.ContainsKey(ltr))
                    dict[ltr] = dict[ltr] + 1;
                else
                    dict.Add(ltr, 1);
            }

            foreach (var noteLtr in ransomNote.ToCharArray())
            {
                if (dict.ContainsKey(noteLtr))
                {
                    if (dict[noteLtr] == 1)
                        dict.Remove(noteLtr);
                    else
                        dict[noteLtr] = dict[noteLtr] - 1;
                }
                else
                    return false;
            }

            return true;
        }
    }
}
