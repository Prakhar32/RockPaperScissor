namespace Gameplay.RulesComposition
{
    public class RulebookFactory
    {
        public Rule CreateRulebook() 
        {
            Rule rulebook = new ScissorLizardRule(new ScissorPaperRule(new ScissorRockRule(new ScissorSpockRule(
                new RockLizardRule(new RockPaperRule(new RockSpockRule(new PaperLizardRule(new PaperSpockRule(new SpockLizardRule(new NoRule()))))))))));
            return rulebook;
        }
    }
}