using System;
using TaleWorlds.MountAndBlade;

namespace GetCompanionItemsUponDeath
{
    public partial class GetCompanionItemsUponDeathSubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            try {
            }
            catch (Exception ex) {
                Error(ex, "Could not apply all generic attribute-based harmony patches.");
            }
            
            base.OnSubModuleLoad();
        }
        
        public override void OnMissionBehaviourInitialize(Mission mission)
        {
            base.OnMissionBehaviourInitialize(mission);
        }
    }
}