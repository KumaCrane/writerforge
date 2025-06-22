using Microsoft.AspNetCore.Mvc;
using WriterForge.Services;
using System.Collections.Generic;

namespace WriterForge.Controllers
{
    // Заготовка для Writer API контроллера

    [ApiController]
    [Route("api/[controller]")]
    public class WriterController : ControllerBase
    {
        private readonly IWordCounterService _wordCounter;
        private readonly ITimerService _timer;
        private readonly IMusicIntegrationService _music;
        private readonly ISpellCheckerService _spellChecker;
        // ...другие сервисы...

        public WriterController(
            IWordCounterService wordCounter,
            ITimerService timer,
            IMusicIntegrationService music,
            ISpellCheckerService spellChecker)
        {
            _wordCounter = wordCounter;
            _timer = timer;
            _music = music;
            _spellChecker = spellChecker;
        }

        [HttpPost("countwords")]
        public ActionResult<int> CountWords([FromBody] string text)
        {
            return _wordCounter.CountWords(text);
        }

        [HttpPost("starttimer")]
        public IActionResult StartTimer([FromQuery] int minutes)
        {
            _timer.StartTimer(minutes);
            return Ok();
        }

        [HttpPost("playmusic")]
        public IActionResult PlayMusic([FromQuery] string track)
        {
            _music.Play(track);
            return Ok();
        }

        [HttpPost("checkspelling")]
        public ActionResult<IEnumerable<string>> CheckSpelling([FromBody] string text)
        {
            return Ok(_spellChecker.CheckSpelling(text));
        }

        [HttpPost("updatetext")]
        public IActionResult UpdateText()
        {
            using (var reader = new System.IO.StreamReader(Request.Body))
            {
                var text = reader.ReadToEndAsync().Result;
                if (_wordCounter is Services.WordCounterService wc)
                    wc.UpdateText(text);
            }
            return Ok();
        }

        [HttpGet("wordcount")]
        public ActionResult<int> GetWordCount()
        {
            if (_wordCounter is Services.WordCounterService wc)
                return wc.GetLastCount();
            return 0;
        }
        // ...методы API...
    }
}
