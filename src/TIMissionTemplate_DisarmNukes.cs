using System.Collections.Generic;
using PavonisInteractive.TerraInvicta;

namespace DisarmNukesMission
{
    // ReSharper disable InconsistentNaming
    public class TIMissionTemplate_DisarmNukes : TIMissionTemplate
    {
        public TIMissionTemplate_DisarmNukes(Settings settings) : base("DisarmNukes")
        {
            dataName = "DisarmNukes";
            friendlyName = "Disarm Nukes";
            disable = !settings.Enabled;
            baseMission = false;
            persistentEffect = false;
            noise = new[] { 12f, 5f, 0f, 0f, 0f, -4f };
            hate = new[] { 3f, 0f, 0f, 0f, 4f, 0f };
            specialPost = false;
            permanentAssignment = false;
            XPonSuccess = 4;
            sortOrder = 11;
            missionContext = MissionContext.EarthOnly;
            utilityScore = 1;
            UIalertEnemyOnFail = true;
            AIDoubleUpAllowed = false;
            maximumTargetOptionCount = 20;
            resolutionOrder = 2;
            allowedForAutoDefense = false;
            resolutionMethod = new TIMissionResolution_Contested()
            {
                attackingModifiers = new List<TIMissionModifier>()
                {
                    new TIMissionModifier_CouncilorAttackStat()
                    {
                        attackerAttribute = CouncilorAttribute.Espionage
                    },
                    new TIMissionModifier_ResourceSpent(),
                    new TIMissionModifier_NationUnrest()
                },
                defendingModifiers = new List<TIMissionModifier>()
                {
                    new TIMissionModifier_FlatModifier()
                    {
                        flatModifier = 17f
                    },
                    new TIMissionModifier_JointControlPointStat()
                    {
                        defenderAttribute = CouncilorAttribute.Security
                    },
                    new TIMissionModifier_AlienNation()
                }
            };
            attackerContexts = new List<Context> { Context.Mission_SabotageFacilities_Att, Context.None };
            defenderContexts = new List<Context> { Context.Mission_SabotageFacilities_Def };
            conditions = new List<TIMissionCondition>
            {
                new TIMissionCondition_TargetInRange(),
                new TIMissionCondition_CouncilorOnEarth(),
                new TIMissionCondition_HasNukes()
            };
            movementRule = MissionMovementRule.MoveToTarget;
            councilorEffects = new List<TIMissionEffect>();
            target = new TIMissionTarget_Nation();
            targetEffects = new List<TIMissionEffect>
            {
                new TIMissionEffect_DisarmNukes()
            };
            cost = new TIMissionCost_Bonus()
            {
                resourceType = FactionResource.Operations,
            };
            missionIconImagePath = "operations/Launch_Nuke";
            targetingMethodType = typeof(TIMissionTargeting_Nation);
            completedIllustrationResource = new List<string> { "illustrations/Event_LaunchPadFire" };
        }
    }
}
