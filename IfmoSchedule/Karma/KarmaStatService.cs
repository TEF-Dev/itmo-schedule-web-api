using System;
using System.Collections.Generic;

namespace IfmoSchedule.Karma
{
    public class KarmaStatService
    {
        private KarmaModel _karma;

        public KarmaStatService()
        {
            _karma = KarmaRepository.GetAddData();
        }

        private int GetKarma(string from, string to)
        {
            return _karma.Data[to][from];
        }

        //bool - is sent
        public bool SendKarma(string from, string to)
        {
            bool sent = false;
            throw new NotImplementedException();

            //TODO: check if userKarma is > -100
            if (sent)
            {
                KarmaRepository.SaveData(_karma);
            }
        }

        public Dictionary<string, int> GetAllUserKarma()
        {
            var res = new Dictionary<string, int>();

            foreach (var list in _karma.Data)
            {
                int totalKarma = 0;
                foreach (var i in list.Value)
                {
                    if (list.Key != i.Key)
                    {
                        totalKarma += GetKarma(list.Key, i.Key)
                                      - GetKarma(i.Key, list.Key);
                    }
                }
                res.Add(list.Key, totalKarma);
            }

            return res;
        }
    }
}