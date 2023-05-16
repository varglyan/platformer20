using System.Linq;
using UnityEditor;

public class ContinuousIntegration
{
/// <summary>
/// Запуск билда под Windows через командную строку
/// </summary>
public static void BuildWin()
{
Build(BuildTarget.Android, "Build/Platformer20.apk");
}

/// <summary>
/// Запуск билда под необходимую платформу
/// </summary>
/// <param name="target">платформа</param>
/// <param name="outPath">путь для билда</param>
public static void Build(BuildTarget target, string outPath)
{
var options = new BuildPlayerOptions
{
target = target,
//собираем все сцены необходимые включить в билд
scenes = (from settingsScene in EditorBuildSettings.scenes
where settingsScene.enabled
select settingsScene.path).ToArray(),
locationPathName = outPath
};
BuildPipeline.BuildPlayer(options);
}
}