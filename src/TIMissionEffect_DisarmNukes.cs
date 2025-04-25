using PavonisInteractive.TerraInvicta;

namespace DisarmNukesMission
{
    // ReSharper disable InconsistentNaming
    public class TIMissionEffect_DisarmNukes: TIMissionEffect
    {
        public override string ApplyEffect(TIMissionState mission, TIGameState target, TIMissionOutcome outcome = TIMissionOutcome.Success)
        {
            if (!target.isNationState) return string.Empty;

            switch (outcome)
            {
                case TIMissionOutcome.CriticalSuccess:
                    target.ref_nation.ChangeNumNuclearWeapons(-2);
                    break;
                case TIMissionOutcome.Success:
                    target.ref_nation.ChangeNumNuclearWeapons(-1);
                    break;
            }
            return string.Empty;
        }
    }
}
