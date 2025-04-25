using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using ModestTree;
using PavonisInteractive.TerraInvicta;
using PavonisInteractive.TerraInvicta.Systems.Bootstrap;

namespace DisarmNukesMission
{
    [HarmonyPatch(typeof(SolarSystemBootstrap))]
    public static class SolarSystemBootstrapPatch
    {
        private const string SabotageFacilitiesTemplateName = "SabotageFacilities";

        [HarmonyPatch(nameof(SolarSystemBootstrap.Initialize))]
        [HarmonyPostfix]
        public static void InitializePostfix()
        {
            var template = new TIMissionTemplate_DisarmNukes(Main.ModSettings);
            TemplateManager.Add(template, typeof(TIMissionTemplate), true);

            TemplateManager.GetAllTemplates<TICouncilorTypeTemplate>().ForEach(c =>
            {
                if (!c.missionNames.Contains(SabotageFacilitiesTemplateName)) return;
                if (c.missionNames.Contains(template.dataName)) return;

                c._missions = null;
                c.missionNames = c.missionNames.Append(template.dataName).ToArray();
            });

            TemplateManager.GetAllTemplates<TIOrgTemplate>().ForEach(o =>
            {
                if (!o.missionsGrantedNames.Contains(SabotageFacilitiesTemplateName)) return;
                if (o.missionsGrantedNames.Contains(template.dataName)) return;

                o.missionsGrantedNames = o.missionsGrantedNames.Append(template.dataName).ToArray();
            });

            TemplateManager.GetAllTemplates<TITraitTemplate>().ForEach(t =>
            {
                if (!t.missionsGrantedNames.Contains(SabotageFacilitiesTemplateName)) return;
                if (t.missionsGrantedNames.Contains(template.dataName)) return;

                t.missionsGrantedNames = t.missionsGrantedNames.Append(template.dataName).ToList();
            });
        }
    }
}
