using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using XRDevcomfy;

public class PropertyModificationCommandTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ExecuteCommandPass()
    {
        var transform = new GameObject().GetComponent<Transform>();
        var prop = transform.GetType().GetProperty("position");
        var newVal = Vector3.one * 100;
        var oldVal = (Vector3)prop.GetValue(transform);
        var cmd = new PropertyModificationCommand<Vector3>(transform, prop, oldVal, newVal);

        Assert.That((Vector3)transform.position, Is.EqualTo(oldVal));
        cmd.Execute();
        Assert.That((Vector3)transform.position, Is.EqualTo(newVal));
    }

    [Test]
    public void ExecuteCommandRedo()
    {
        var transform = new GameObject().GetComponent<Transform>();
        var prop = transform.GetType().GetProperty("position");
        var newVal = Vector3.one * 100;
        var oldVal = (Vector3)prop.GetValue(transform);
        var cmd = new PropertyModificationCommand<Vector3>(transform, prop, oldVal, newVal);

        Assert.That((Vector3)transform.position, Is.EqualTo(oldVal));
        cmd.Execute();
        Assert.That((Vector3)transform.position, Is.EqualTo(newVal));
        cmd.Undo();
        Assert.That((Vector3)transform.position, Is.EqualTo(oldVal));
    }

}
