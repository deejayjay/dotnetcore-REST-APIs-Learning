const url = "https://localhost:7225/api/albums";

getAlbumRecords(url);

async function getAlbumRecords(url) {
  try {
    const response = await fetch(url);
    const albumData = await response.json();
    console.log(albumData);
  } catch (error) {
    console.log(error.message);
  }
}
