using BddMagic;

namespace ConfluxWritersDay.Tests.Specifications
{
    public class BaseBddFeature : BddFeature
    {
        public BaseBddFeature(string feature, string story)
            : base(feature, story)
        { }

        public Scenario Scenario()
        {
            return this.Scenario("todo: humanize calling method name");
        }
    }
}
