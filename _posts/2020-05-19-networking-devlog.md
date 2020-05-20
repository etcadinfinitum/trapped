---
layout: post
title: WebSocket Adventures and Other Updates
description: A story of SSL/TLS trials and tribulations of getting a live WebGL build on its feet.
---

# Development Log Dated 5-19-2020

## Completed Milestones

- Ensure secured WebSocket connections are made when a WebGL is deployed 
  to a site. (Lizzy)

### The Problem

Up until 5/18, we had been testing all networking functionality locally 
and had not deployed the WebGL build to a hosted website.

The first issue we encountered when deploying a WebGL build was a connection 
exception when attempting to initiate the WebSocket connection from the 
initial scene. The exception produce a console log and generated an 
alert in the browser on Firefox and was related to making insecure 
outbound request 

The fix for this was simple; in the C# script which initiates the 
WebSocket connection in the client, we changed `ws://` to `wss://` like so:

```csharp
w = new WebSocket(new Uri("wss://"+ip+":"+port));
```

This initiates a secure connection for the WebSocket, much like `https` 
initiates a secure connection using the HTTP protocol.

After rebuilding the WebGL files and redeploying, we encountered a second 
issue, visible in the console tab for Chrome and Firefox:

* `Firefox can’t establish a connection to the server at wss://_ip_address_:8000/.` (Firefox)
* `WebSocket connection to 'wss://_ip_address_:8000/' failed: Error in connection establishment: net::ERR_CONNECTION_CLOSED` (Chrome)

This error was also produced in the Unity editor. At this point, I felt 
a little bit like Dr. Gaius Baltar:

<div style="max-width:100%;height:0;padding-bottom:56%;position:relative;"><iframe src="https://giphy.com/embed/52HjuHsfVO69q" width="100%" height="100%" style="position:absolute" frameBorder="0" class="giphy-embed" allowFullScreen></iframe></div><p><a href="https://giphy.com/gifs/reactiongifs-52HjuHsfVO69q">via GIPHY</a></p>

### The Solution

To correct this, there are a few things to keep in mind:

1. `wss` connections require certificates on the server as well as the 
   client (as far as we understand it).
2. You can direct the websocket to a standalone IP instead of a domain, 
   but you [cannot issue a certificate](https://community.letsencrypt.org/t/certificate-for-secured-websocket/77689/14) 
   for a standalone IP.

To correct this, I added a new `A` record for a subdomain that I own; the 
domain name for the websocket server is `ws.lizzy.wiki`. 

I then configured the `nginx` server to listen for inbound traffic on port 
80 tagged with that domain name, and proxied the data to the WebSocket 
port number (8000).

Lastly, I set up a SSL/TLS certificate for the new subdomain on the host 
machine through [Let's Encrypt](https://letsencrypt.org/).

We can then use the nodeJS utility [`wscat`](https://www.npmjs.com/package/wscat) 
to connect to the secured WebSocket server via the command line:

```console
$ wscat -c wss://ws.lizzy.wiki
Connected (press CTRL+C to quit)
< {"players":[]}
[more output, every 0.1 seconds]
< {"players":[]}
> 
[ctrl-c]
$
```

Sure enough, the new `wss` connection also works from the Unity editor 
when the new domain is explicitly specified; the error that occurred 
before appears to have been fixed.

Additional testing is needed from a hosted WebGL build, but this solution 
appears to be on the right track.

## Current Work & Other Information

No additional updates on task delegation, playtesting, blockers, or 
upcoming features; I wanted to share the roller-coaster 
ride of getting a networked game running on a host site.

## Reflection

This nightmarish scenario required me to brush off my `nginx` knowledge 
(or, in most cases, relearn it). However, I feel good about the work 
I did to get this configured correctly. Lastly, I _sincerely_ hope this 
is the last time I have to grapple with TLS issues for this project, 
though I doubt this will be the case.

