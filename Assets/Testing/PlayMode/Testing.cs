using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Testing
{

    [UnityTest]
    public IEnumerator HidingTest()
    {
        SceneManager.LoadScene("Testing2");

        yield return new WaitForFixedUpdate();

        GameObject player = GameObject.Find("FirstPerson");
        GameObject table = GameObject.Find("Table");
        Interaction interacter = player.GetComponent<Interaction>();
        Hide hide = table.GetComponent<Hide>();

        yield return new WaitForSeconds(1);

        Vector3 originPosition = player.transform.position;

        interacter.Interact();

        yield return new WaitForSeconds(2);

        hide.StopHiding(); 

        Assert.IsTrue((originPosition == player.transform.position));
    }

    [UnityTest]
    public IEnumerator MonsterHearTest()
    {
        SceneManager.LoadScene("Testing2");

        yield return new WaitForFixedUpdate();

        GameObject e = GameObject.Find("Creature_01_Mesh");
        Enemy enemy = e.GetComponent<Enemy>();

        bool initialFalse = enemy.FollowingSound;

        yield return new WaitForSeconds(5);

        Assert.IsTrue(initialFalse != enemy.FollowingSound);
    }

    [UnityTest]
    public IEnumerator SneakWalkTest()
    {
        SceneManager.LoadScene("TestCrouch");

        yield return new WaitForFixedUpdate();

        GameObject player = GameObject.Find("FirstPerson");
        PlayerMovement movement = player.GetComponent<PlayerMovement>();

        movement.SneakWalk();

        Assert.IsTrue(movement.move == movement.sneakWalkSpeed);
    }

    [UnityTest]
    public IEnumerator UltimateTest()
    {
        SceneManager.LoadScene("TestCrouch");

        yield return new WaitForFixedUpdate();

        GameObject flowerB = GameObject.Find("blueFlower");
        GameObject flowerR = GameObject.Find("redFlower");
        GameObject key = GameObject.Find("key2");
        GameObject player = GameObject.Find("FirstPerson");

        PlayerMovement movement = player.GetComponent<PlayerMovement>();

        Material materialB = flowerB.GetComponent<Renderer>().sharedMaterial;
        Material materialR = flowerR.GetComponent<Renderer>().sharedMaterial;
        Material materialkey = key.GetComponent<Renderer>().sharedMaterial;

        Color mix = materialB.color + materialR.color;

        Assert.IsTrue(materialkey.color == mix);

        movement.SneakWalk();

        Assert.IsTrue(movement.move == movement.sneakWalkSpeed);

        SceneManager.LoadScene("Testing2");

        yield return new WaitForFixedUpdate();

        GameObject e = GameObject.Find("Creature_01_Mesh");
        Enemy enemy = e.GetComponent<Enemy>();
        GameObject player2 = GameObject.Find("FirstPerson");
        GameObject table = GameObject.Find("Table");
        Interaction interacter = player2.GetComponent<Interaction>();
        Hide hide = table.GetComponent<Hide>();

        bool initialFalse = enemy.FollowingSound;

        yield return new WaitForSeconds(5);

        Assert.IsTrue(initialFalse != enemy.FollowingSound);

        Vector3 originPosition = player2.transform.position;

        interacter.Interact();

        yield return new WaitForSeconds(2);

        hide.StopHiding();

        Assert.IsTrue((originPosition == player2.transform.position));
    }

    [UnityTest]
    public IEnumerator ColorTest()
    {
        SceneManager.LoadScene("TestCrouch");
        yield return new WaitForFixedUpdate();

        GameObject flowerB = GameObject.Find("blueFlower");
        GameObject flowerR = GameObject.Find("redFlower");
        GameObject key = GameObject.Find("key2");

        Material materialB = flowerB.GetComponent<Renderer>().sharedMaterial;
        Material materialR = flowerR.GetComponent<Renderer>().sharedMaterial;
        Material materialkey = key.GetComponent<Renderer>().sharedMaterial;

        Color mix = materialB.color + materialR.color;

        yield return new WaitForSeconds(5);

        Assert.IsTrue(materialkey.color == mix);
    }
}
