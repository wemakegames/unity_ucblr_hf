﻿using UnityEngine;
using System.Collections;
using HappyFunTimes;

public class HappySpawner : MonoBehaviour {

	public GameObject PrefabToSpawnForPlayer;

	GameServer server;
	int playerCount;

	// Use this for initialization
	void Start () {
		var options = new GameServer.Options();
		options.gameId = "unity_ucblr";
		options.controllerUrl = "http://localhost:8080/examples/ucblr/index.html";

		server = new GameServer(options, gameObject);
		server.OnPlayerConnect += StartNewPlayer;
		server.OnConnect += Connected;
		server.OnDisconnect += Disconnected;
		server.Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartNewPlayer(object sender, PlayerConnectMessageArgs e){

		Debug.Log("HappySpawner:StartNewPlayer");

		Vector3 spawnPosition = transform.position + new Vector3(
			Random.Range(-10f, 10f),
			1f,
			0
			);


		// Spawn a new player then add a script to it.
		var go = (GameObject)Instantiate(PrefabToSpawnForPlayer, spawnPosition, transform.rotation);

		// Get the Example3rdPersonController script to this object.
		var player = go.GetComponent<HappyController>();
		player.Init(e.netPlayer, "Player" + (++playerCount));
	}
	
	void Connected(object sender, System.EventArgs e) {
		Debug.Log("HappySpawner:Connected");
	}
	
	void Disconnected(object sender, System.EventArgs e) {
		Debug.Log("HappySpawner:Disconnected");
	}
	
	void Cleanup() {
		if (server != null) {
			server.Close();
			server = null;
		}
	}
	
	void OnDestroy() {
		Cleanup();
	}
	
	void OnApplicationExit() {
		Cleanup();
	}
}
