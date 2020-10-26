using System.Collections.Generic;

namespace Common
{
    public class Player
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public List<PlayerGameSnapshot> PlayerGameSnapshots { get; set; }
        public List<Game> Games { get; set; }
    }
}