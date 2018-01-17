using System;
using OpenTK;
using OpenTK.Graphics;
using static SDL2.SDL;

namespace SdlSetup
{
    internal class Game
    {
        private IntPtr _renderer;
        private IntPtr _window;
        private bool _isGameRunning = true;
        private string _windowTitle = "SDL";
        private int _windowWidth = 1024;
        private int _windowHeight = 768;
        private SDL_WindowFlags _windowFlags = SDL_WindowFlags.SDL_WINDOW_SHOWN | SDL_WindowFlags.SDL_WINDOW_OPENGL;
        private IntPtr _glContext;

        public void Run()
        {
            Initialise();
            Loop();
            Quit();
        }

        private void Initialise()
        {
            if (SDL_Init(SDL_INIT_EVERYTHING) != 0)
            {
                throw new Exception("Couldn't initialise SDL");
            }

            _window = SDL_CreateWindow(_windowTitle, SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, _windowWidth, _windowHeight, _windowFlags);

            if (_window == null)
            {
                throw new Exception("Window couldn't be created");
            }

            _glContext = SDL_GL_CreateContext(_window);
            GraphicsContext.CurrentContextHandle.Handle = _glContext;

            _renderer = SDL_CreateRenderer(_window, 0, SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

            if (_renderer == null)
            {
                throw new Exception("Renderer couldn't be created");
            }
        }

        private void Loop()
        {
            while (_isGameRunning)
            {
                while (SDL_PollEvent(out var sdlEvent) != 0)
                {
                    switch (sdlEvent.type)
                    {
                        case SDL_EventType.SDL_QUIT:
                            _isGameRunning = false;
                            break;
                    }
                }

                Update();

                Draw();
            }
        }

        private void Update()
        {
            
        }

        private void Draw()
        {
            //SDL_SetRenderDrawColor(_renderer, 0, 0, 0, 255);

            //SDL_RenderClear(_renderer);

            //var rect = new SDL_Rect()
            //{
            //    x = 50,
            //    y = 50,
            //    w = 50,
            //    h = 50
            //};

            //SDL_SetRenderDrawColor(_renderer, 255, 0, 0, 255);
            //SDL_RenderFillRect(_renderer, ref rect);

            //SDL_RenderPresent(_renderer);

            
        }


        private void Quit()
        {
            SDL_DestroyRenderer(_renderer);
            SDL_DestroyWindow(_window);
            SDL_Quit();
        }
    }
}
