﻿// Copyright (C) 2018 Singapore ETH Centre, Future Cities Laboratory
// All rights reserved.
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
// Author:  Michael Joos  (joos@arch.ethz.ch)

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum MessageType
{
	Info,
	Warning,
	Error
}

public class ToolMessenger : MonoBehaviour
{
	[Header("UI Refecences")]
	public GameObject warningImage;
	public GameObject errorImage;
	public Text messageText;
	public GameObject examplePanel;
	public Text exampleText;
	public Button exampleButton;


	public void Show(string msg, MessageType type, string example = null)
	{
		messageText.text = msg;

		examplePanel.SetActive(false);

		if (type == MessageType.Warning)
		{
			warningImage.SetActive(true);
		}
		else if (type == MessageType.Error)
		{
			errorImage.SetActive(true);
		}
		else
		{
			warningImage.SetActive(false);
			errorImage.SetActive(false);
		}

		gameObject.SetActive(true);

		GuiUtils.RebuildLayout(transform.parent);
	}

	public void SetExample(string example, UnityAction action = null)
	{
		exampleText.text = example;
		if (action != null)
		{
			exampleButton.onClick.AddListener(action);
			exampleButton.gameObject.SetActive(true);
		}
		else
		{
			exampleButton.gameObject.SetActive(false);
		}
		examplePanel.SetActive(true);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}
}
