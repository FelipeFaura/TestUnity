using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DashTest
{
    [UnityTest]
    public IEnumerator DashTestPosition()
    {
        GameObject player = new GameObject();
        Player playerScript = player.AddComponent<Player>();

        Assert.AreEqual(new Vector3(0, 0, 0), player.transform.position);
        playerScript.dashMovement();
        Assert.AreEqual(playerScript.dashValue, 10);
        Assert.AreEqual(new Vector3(playerScript.dashValue, 0, 0), player.transform.position);
        yield return null;
    }
}
