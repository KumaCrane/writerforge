// Счётчик слов
function updateTextAndCount() {
  const text = document.getElementById('textInput').value;
  const count = text.trim() ? text.trim().split(/\s+/).length : 0;
  document.getElementById('wordCountDisplay').innerText = count;
}
setInterval(updateTextAndCount, 1000);

// Таймер
let timerRunning = false;
let timerInterval = null;
let timerSeconds = 30 * 60;

function formatTimer(secs) {
  const m = Math.floor(secs / 60).toString().padStart(2, '0');
  const s = (secs % 60).toString().padStart(2, '0');
  return `${m}:${s}`;
}

function updateTimerDisplay() {
  document.getElementById('timerDisplay').innerText = formatTimer(timerSeconds);
}

function timerTick() {
  if (timerRunning && timerSeconds > 0) {
    timerSeconds--;
    updateTimerDisplay();
    if (timerSeconds === 0) {
      timerRunning = false;
      clearInterval(timerInterval);
    }
  }
}

function toggleTimer() {
  if (!timerRunning) {
    timerRunning = true;
    timerInterval = setInterval(timerTick, 1000);
  } else {
    timerRunning = false;
    clearInterval(timerInterval);
  }
}

document.getElementById('pauseBtn').addEventListener('click', toggleTimer);
updateTimerDisplay();

// PDF сохранение
document.getElementById('savePdfBtn').addEventListener('click', function() {
  const text = document.getElementById('textInput').value;
  const doc = new window.jspdf.jsPDF({ 
    orientation: 'p', 
    unit: 'mm', 
    format: 'a4',
  });
  doc.setFont("helvetica", "normal");
  doc.setFontSize(14);
  const lines = doc.splitTextToSize(text, 180);
  doc.text(lines, 10, 20, { baseline: 'top' });
  doc.save('text.pdf');
});

// Мотивационные фразы
let phrases = [
  "Ты молодец, продолжай писать!",
  "Каждая строка — шаг к успеху.",
  "Не сдавайся, вдохновение рядом!",
  "Твои идеи важны, делись ими!",
  "Сделай сегодня чуть больше, чем вчера.",
  "Вдохновляйся и вдохновляй других!",
  "Пиши с удовольствием!"
];
let phraseIdx = 0;

function showNextPhrase() {
  if (!phrases.length) return;
  phraseIdx = (phraseIdx + 1) % phrases.length;
  document.getElementById('mascot-bubble').innerText = phrases[phraseIdx];
}
function initMascotBubble() {
  if (phrases.length) {
    phraseIdx = Math.floor(Math.random() * phrases.length);
    document.getElementById('mascot-bubble').innerText = phrases[phraseIdx];
    setInterval(showNextPhrase, 10000);
  }
}
initMascotBubble();

// MUSIC PLAYER LOGIC
let playlist = [];
let currentTrack = 0;
let isPlaying = false;
const audio = document.getElementById('musicPlayer');
const playlistInput = document.getElementById('playlistInput');

function parsePlaylist(input) {
  input = input.trim();
  if (/vk\.com|music\.yandex\.ru/.test(input)) {
    return [input];
  }
  return input.split(/[\n,]+/).map(x => x.trim()).filter(Boolean);
}

function loadTrack(idx) {
  if (!playlist.length) return;
  currentTrack = ((idx % playlist.length) + playlist.length) % playlist.length;
  audio.src = playlist[currentTrack];
  audio.load();
  if (isPlaying) audio.play();
}

function playPauseMusic() {
  if (!playlist.length) return;
  if (/vk\.com|music\.yandex\.ru/.test(playlist[currentTrack])) {
    window.open(playlist[currentTrack], '_blank');
    return;
  }
  if (audio.paused) {
    audio.play();
    isPlaying = true;
  } else {
    audio.pause();
    isPlaying = false;
  }
}

function nextTrack() {
  if (!playlist.length) return;
  if (/vk\.com|music\.yandex\.ru/.test(playlist[currentTrack])) {
    window.open(playlist[currentTrack], '_blank');
    return;
  }
  loadTrack(currentTrack + 1);
  if (isPlaying) audio.play();
}

function prevTrack() {
  if (!playlist.length) return;
  if (/vk\.com|music\.yandex\.ru/.test(playlist[currentTrack])) {
    window.open(playlist[currentTrack], '_blank');
    return;
  }
  loadTrack(currentTrack - 1);
  if (isPlaying) audio.play();
}

function handlePlaylistInput() {
  playlist = parsePlaylist(playlistInput.value);
  currentTrack = 0;
  if (playlist.length) {
    if (/vk\.com|music\.yandex\.ru/.test(playlist[0])) {
      isPlaying = false;
      audio.pause();
      audio.src = "";
    } else {
      loadTrack(0);
      isPlaying = false;
      audio.pause();
    }
  }
}
playlistInput.addEventListener('change', handlePlaylistInput);
playlistInput.addEventListener('blur', handlePlaylistInput);
playlistInput.addEventListener('keydown', function(e) {
  if (e.key === 'Enter') {
    handlePlaylistInput();
    playlistInput.blur();
  }
});

document.querySelector('.play-wrapper').addEventListener('click', playPauseMusic);
document.querySelector('.angle-left-wrapper').addEventListener('click', prevTrack);
document.querySelector('.angle-right-wrapper').addEventListener('click', nextTrack);

audio.addEventListener('ended', nextTrack);
