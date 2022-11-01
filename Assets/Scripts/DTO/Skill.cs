using DTO;
namespace DTO {
    [System.Serializable]
    public class Skill {
        public string index;
        public string name;
        public string url;
        public string[] desc;
        public AbilityScore  ability_score;
        //public string skills;
    }
}