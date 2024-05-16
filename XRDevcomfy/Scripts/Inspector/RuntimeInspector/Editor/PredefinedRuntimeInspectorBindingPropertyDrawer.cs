/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace XRDevcomfy.RuntimeInspector
{
    [CustomPropertyDrawer(typeof(PredefinedRuntimeInspector.TargetBinding))]
    public class PredefinedRuntimeInspectorBindingPropertyDrawer : PropertyDrawer
    {
	private const string kTargetProperty = "Target";
	private const string kPropertyName = "PropertyName";

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
	    Rect targetRect = new Rect(position.x, position.y, position.width / 2, position.height);
	    Rect functionRect = new Rect(position.x + position.width/2, position.y, position.width / 2, position.height);
	    
	    var target = property.FindPropertyRelative(kTargetProperty);
	    var targetComponent = target?.objectReferenceValue as Component;
	    var propInfoSerialized = property.FindPropertyRelative(kPropertyName);
	    string propName = propInfoSerialized?.stringValue as string;

	    // var targetProp 
	    label = EditorGUI.BeginProperty(position, GUIContent.none, property);
	    EditorGUI.BeginChangeCheck();
	    {
		EditorGUI.PropertyField(targetRect, target, GUIContent.none);
		if (EditorGUI.EndChangeCheck())
		{
		}
	    }
	    
	    if (EditorGUI.DropdownButton(functionRect, new GUIContent($"{targetComponent}.{propName}"), FocusType.Passive, EditorStyles.popup))
		BuildPopupList(targetComponent?.gameObject, property).DropDown(functionRect);
	    EditorGUI.EndProperty();
	}


	// https://github.com/Unity-Technologies/UnityCsReference/blob/master/Editor/Mono/Inspector/UnityEventDrawer.cs#L638
	/// <summary>Builds Pop up list to select properties.</summary>
	GenericMenu BuildPopupList(GameObject target, SerializedProperty property)
	{
	    var menu = new GenericMenu();
	    var propName = property.FindPropertyRelative(kPropertyName);
	    var targetComponent = property.FindPropertyRelative(kTargetProperty);
	    string targetQualifiedName = property.FindPropertyRelative("TargetQualifiedName").stringValue;

	    Type _type;
	    foreach (var component in target.GetComponents<Component>())
	    {
		_type = component.GetType();
		string qualifiedName = _type.AssemblyQualifiedName;
		foreach (PropertyInfo prop in _type.GetProperties())
		{
		    menu.AddItem(new GUIContent($"{_type}/{prop.Name}"),
				 prop.Name == propName.stringValue && component == targetComponent.objectReferenceValue,
				 () =>
				 {
				     propName.stringValue = prop.Name;
                                     targetComponent.objectReferenceValue = component;
				     property.serializedObject.ApplyModifiedProperties();
				 });
		}
	    }
	    return menu;
	}
    }
}
