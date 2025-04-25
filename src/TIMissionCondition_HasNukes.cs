using PavonisInteractive.TerraInvicta;

namespace DisarmNukesMission
{
    // ReSharper disable InconsistentNaming
    public class TIMissionCondition_HasNukes: TIMissionCondition
    {
        public override string CanTarget(TICouncilorState councilor, TIGameState possibleTarget)
        {
            return possibleTarget.isNationState && possibleTarget.ref_nation.numNuclearWeapons > 0 ? "_Pass" : this.GetType().Name;
        }
    }
}
