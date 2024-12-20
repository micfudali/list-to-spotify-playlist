import spotipy
from spotipy.oauth2 import SpotifyOAuth
from dotenv import load_dotenv
import os

load_dotenv()


CLIENT_ID = os.getenv("CLIENT_ID")
CLIENT_SECRET = os.getenv("CLIENT_SECRET")
REDIRECT_URI = os.getenv("REDIRECT_URI")

SCOPES = "playlist-modify-public playlist-modify-private"

sp = spotipy.Spotify(auth_manager=SpotifyOAuth(
    client_id=CLIENT_ID,
    client_secret=CLIENT_SECRET,
    redirect_uri=REDIRECT_URI,
    scope=SCOPES
))

playlist_name = "Fantano Top 50 Singles 2024"

user_id = sp.current_user()["id"]

playlist = sp.user_playlist_create(user=user_id, name=playlist_name)
playlist_id = playlist["id"]
print(f"Utworzono playlistę: {playlist['external_urls']['spotify']}")

file_path = "../songs_list.txt"

with open(file_path, "r", encoding="utf-8") as file:
    for line in file:
        track_name = line.strip()
        if track_name:
            results = sp.search(q=track_name, type="track", limit=1)
            if results["tracks"]["items"]:
                track_id = results["tracks"]["items"][0]["id"]
                sp.playlist_add_items(playlist_id, [track_id])
                print(f"Dodano utwór: {track_name}")
            else:
                print(f"Nie znaleziono utworu: {track_name}")
