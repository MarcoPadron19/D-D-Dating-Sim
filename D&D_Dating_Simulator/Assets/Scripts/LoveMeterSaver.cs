using UnityEngine;

namespace PixelCrushers
{

    /// This is a starter template for Save System savers. To use it,
    /// make a copy, rename it, and remove the line marked above.
    /// Then fill in your code where indicated below.
    public class LoveMeterSaver : Saver // Rename this class.
    {

        public override string RecordData()
        {
            var Player = GetComponent<Player>();
            return Player.currentLove.ToString();
        }

        public override void ApplyData(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return;
            }
            var Player = GetComponent<Player>();
            Player.currentLove = SafeConvert.ToInt(data);

            var Love = FindObjectOfType<LoveMeter>();
            Love.SetLoveMeter(SafeConvert.ToInt(data));
        }

        //public override void ApplyDataImmediate()
        //{
        //    // If your Saver needs to pull data from the Save System immediately after
        //    // loading a scene, instead of waiting for ApplyData to be called at its
        //    // normal time, which may be some number of frames after the scene has started,
        //    // it can implement this method. For efficiency, the Save System will not look up 
        //    // the Saver's data; your method must look it up manually by calling 
        //    // SaveSystem.savedGameData.GetData(key).
        //}

        //public override void OnBeforeSceneChange()
        //{
        //    // The Save System will call this method before scene changes. If your saver listens for 
        //    // OnDisable or OnDestroy messages (see DestructibleSaver for example), it can use this 
        //    // method to ignore the next OnDisable or OnDestroy message since they will be called
        //    // because the entire scene is being unloaded.
        //}

        //public override void OnRestartGame()
        //{
        //    // The Save System will call this method when restarting the game from the beginning.
        //    // Your Saver can reset things to a fresh state if necessary.
        //}

    }

}

/**/
