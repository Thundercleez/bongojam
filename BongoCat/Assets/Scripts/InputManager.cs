﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InputManager : Singleton<InputManager> {

    public static float inputBuffer = .016f * 3;


    public enum ActionsEnum { JUMP_LEFT, JUMP_RIGHT, DOUBLE_JUMP, JUMP_COMMITED };

    public class InputEntry
    {
        public float inputTime;
        public ActionsEnum inputAction;
        public bool processed;
    }

    public List<InputEntry> inputEntries;

    private void Awake()
    {
        inputEntries = new List<InputEntry>();
    }

    private void Update()
    {
        ReadInputs();
    }

    void ReadInputs()
    {
        for (int i = inputEntries.Count - 1; i >= 0; i--)
        {
            if (Time.time - inputEntries[i].inputTime >= inputBuffer)
            {
                inputEntries.RemoveAt(i);
            }
        }

        for (int i = 0; i < Globals.Instance.keyMappings.Count; i++)
        {
            if (Input.GetKeyUp(Globals.Instance.keyMappings[0][i]) || Input.GetKeyDown(Globals.Instance.keyMappings[1][i]))
            {
                if (i == (int)Globals.InputIndexMappingEnum.LEFT_INPUT_INDEX)
                {
                    RemoveInputEntry(ActionsEnum.JUMP_LEFT);
                }
                else
                {
                    RemoveInputEntry(ActionsEnum.JUMP_RIGHT);
                }
                bool isCommitted = false;
                for(int j = 0; j < inputEntries.Count; j++)
                {
                    if(inputEntries[j].inputAction == ActionsEnum.JUMP_COMMITED)
                    {
                        isCommitted = true;
                        break;
                    }
                }
                if (!isCommitted)
                {
                    InputEntry ie = new InputEntry();
                    ie.inputTime = Time.time;
                    ie.inputAction = ActionsEnum.JUMP_COMMITED;
                    inputEntries.Add(ie);
                }
            }

            if (Input.GetKeyDown(Globals.Instance.keyMappings[0][i]) || Input.GetKeyDown(Globals.Instance.keyMappings[1][i]))
            {
                InputEntry ie = new InputEntry();
                ie.inputTime = Time.time;
                if (i == (int)Globals.InputIndexMappingEnum.LEFT_INPUT_INDEX)
                {
                    ie.inputAction = ActionsEnum.JUMP_LEFT;
                }
                else
                {
                    ie.inputAction = ActionsEnum.JUMP_RIGHT;
                }

                if ( (inputEntries.Count == 1 && inputEntries[0].inputAction != ActionsEnum.JUMP_COMMITED) ||
                    (inputEntries.Count > 1))
                {
                    ie.inputAction = ActionsEnum.DOUBLE_JUMP;
                }
                inputEntries.Insert(0, ie);
            }
        }
    }

    void RemoveInputEntry(ActionsEnum action)
    {
        for(int i = inputEntries.Count - 1; i >= 0; i--)
        {
            if(inputEntries[i].inputAction == action)
            {
                inputEntries.RemoveAt(i);
            }
        }
    }

    public static KeyCode WhichKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) { return KeyCode.Backspace; }

        if (Input.GetKeyDown(KeyCode.Delete)) { return KeyCode.Delete; }

        if (Input.GetKeyDown(KeyCode.Tab)) { return KeyCode.Tab; }

        if (Input.GetKeyDown(KeyCode.Clear)) { return KeyCode.Clear; }

        if (Input.GetKeyDown(KeyCode.Return)) { return KeyCode.Return; }

        if (Input.GetKeyDown(KeyCode.Pause)) { return KeyCode.Pause; }

        if (Input.GetKeyDown(KeyCode.Escape)) { return KeyCode.Escape; }

        if (Input.GetKeyDown(KeyCode.Space)) { return KeyCode.Space; }

        if (Input.GetKeyDown(KeyCode.Keypad0)) { return KeyCode.Keypad0; }

        if (Input.GetKeyDown(KeyCode.Keypad1)) { return KeyCode.Keypad1; }

        if (Input.GetKeyDown(KeyCode.Keypad2)) { return KeyCode.Keypad2; }

        if (Input.GetKeyDown(KeyCode.Keypad3)) { return KeyCode.Keypad3; }

        if (Input.GetKeyDown(KeyCode.Keypad4)) { return KeyCode.Keypad4; }

        if (Input.GetKeyDown(KeyCode.Keypad5)) { return KeyCode.Keypad5; }

        if (Input.GetKeyDown(KeyCode.Keypad6)) { return KeyCode.Keypad6; }

        if (Input.GetKeyDown(KeyCode.Keypad7)) { return KeyCode.Keypad7; }

        if (Input.GetKeyDown(KeyCode.Keypad8)) { return KeyCode.Keypad8; }

        if (Input.GetKeyDown(KeyCode.Keypad9)) { return KeyCode.Keypad9; }

        if (Input.GetKeyDown(KeyCode.KeypadPeriod)) { return KeyCode.KeypadPeriod; }

        if (Input.GetKeyDown(KeyCode.KeypadDivide)) { return KeyCode.KeypadDivide; }

        if (Input.GetKeyDown(KeyCode.KeypadMultiply)) { return KeyCode.KeypadMultiply; }

        if (Input.GetKeyDown(KeyCode.KeypadMinus)) { return KeyCode.KeypadMinus; }

        if (Input.GetKeyDown(KeyCode.KeypadPlus)) { return KeyCode.KeypadPlus; }

        if (Input.GetKeyDown(KeyCode.KeypadEnter)) { return KeyCode.KeypadEnter; }

        if (Input.GetKeyDown(KeyCode.KeypadEquals)) { return KeyCode.KeypadEquals; }

        if (Input.GetKeyDown(KeyCode.UpArrow)) { return KeyCode.UpArrow; }

        if (Input.GetKeyDown(KeyCode.DownArrow)) { return KeyCode.DownArrow; }

        if (Input.GetKeyDown(KeyCode.RightArrow)) { return KeyCode.RightArrow; }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) { return KeyCode.LeftArrow; }

        if (Input.GetKeyDown(KeyCode.Insert)) { return KeyCode.Insert; }

        if (Input.GetKeyDown(KeyCode.Home)) { return KeyCode.Home; }

        if (Input.GetKeyDown(KeyCode.End)) { return KeyCode.End; }

        if (Input.GetKeyDown(KeyCode.PageUp)) { return KeyCode.PageUp; }

        if (Input.GetKeyDown(KeyCode.PageDown)) { return KeyCode.PageDown; }

        if (Input.GetKeyDown(KeyCode.F1)) { return KeyCode.F1; }

        if (Input.GetKeyDown(KeyCode.F2)) { return KeyCode.F2; }

        if (Input.GetKeyDown(KeyCode.F3)) { return KeyCode.F3; }

        if (Input.GetKeyDown(KeyCode.F4)) { return KeyCode.F4; }

        if (Input.GetKeyDown(KeyCode.F5)) { return KeyCode.F5; }

        if (Input.GetKeyDown(KeyCode.F6)) { return KeyCode.F6; }

        if (Input.GetKeyDown(KeyCode.F7)) { return KeyCode.F7; }

        if (Input.GetKeyDown(KeyCode.F8)) { return KeyCode.F8; }

        if (Input.GetKeyDown(KeyCode.F9)) { return KeyCode.F9; }

        if (Input.GetKeyDown(KeyCode.F10)) { return KeyCode.F10; }

        if (Input.GetKeyDown(KeyCode.F11)) { return KeyCode.F11; }

        if (Input.GetKeyDown(KeyCode.F12)) { return KeyCode.F12; }

        if (Input.GetKeyDown(KeyCode.F13)) { return KeyCode.F13; }

        if (Input.GetKeyDown(KeyCode.F14)) { return KeyCode.F14; }

        if (Input.GetKeyDown(KeyCode.F15)) { return KeyCode.F15; }

        if (Input.GetKeyDown(KeyCode.Alpha0)) { return KeyCode.Alpha0; }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { return KeyCode.Alpha1; }

        if (Input.GetKeyDown(KeyCode.Alpha2)) { return KeyCode.Alpha2; }

        if (Input.GetKeyDown(KeyCode.Alpha3)) { return KeyCode.Alpha3; }

        if (Input.GetKeyDown(KeyCode.Alpha4)) { return KeyCode.Alpha4; }

        if (Input.GetKeyDown(KeyCode.Alpha5)) { return KeyCode.Alpha5; }

        if (Input.GetKeyDown(KeyCode.Alpha6)) { return KeyCode.Alpha6; }

        if (Input.GetKeyDown(KeyCode.Alpha7)) { return KeyCode.Alpha7; }

        if (Input.GetKeyDown(KeyCode.Alpha8)) { return KeyCode.Alpha8; }

        if (Input.GetKeyDown(KeyCode.Alpha9)) { return KeyCode.Alpha9; }

        if (Input.GetKeyDown(KeyCode.Exclaim)) { return KeyCode.Exclaim; }

        if (Input.GetKeyDown(KeyCode.DoubleQuote)) { return KeyCode.DoubleQuote; }

        if (Input.GetKeyDown(KeyCode.Hash)) { return KeyCode.Hash; }

        if (Input.GetKeyDown(KeyCode.Dollar)) { return KeyCode.Dollar; }

        //if (Input.GetKeyDown(KeyCode.Percent)) { return KeyCode.Percent; }

        if (Input.GetKeyDown(KeyCode.Ampersand)) { return KeyCode.Ampersand; }

        if (Input.GetKeyDown(KeyCode.Quote)) { return KeyCode.Quote; }

        if (Input.GetKeyDown(KeyCode.LeftParen)) { return KeyCode.LeftParen; }

        if (Input.GetKeyDown(KeyCode.RightParen)) { return KeyCode.RightParen; }

        if (Input.GetKeyDown(KeyCode.Asterisk)) { return KeyCode.Asterisk; }

        if (Input.GetKeyDown(KeyCode.Plus)) { return KeyCode.Plus; }

        if (Input.GetKeyDown(KeyCode.Comma)) { return KeyCode.Comma; }

        if (Input.GetKeyDown(KeyCode.Minus)) { return KeyCode.Minus; }

        if (Input.GetKeyDown(KeyCode.Period)) { return KeyCode.Period; }

        if (Input.GetKeyDown(KeyCode.Slash)) { return KeyCode.Slash; }

        if (Input.GetKeyDown(KeyCode.Colon)) { return KeyCode.Colon; }

        if (Input.GetKeyDown(KeyCode.Semicolon)) { return KeyCode.Semicolon; }

        if (Input.GetKeyDown(KeyCode.Less)) { return KeyCode.Less; }

        if (Input.GetKeyDown(KeyCode.Equals)) { return KeyCode.Equals; }

        if (Input.GetKeyDown(KeyCode.Greater)) { return KeyCode.Greater; }

        if (Input.GetKeyDown(KeyCode.Question)) { return KeyCode.Question; }

        if (Input.GetKeyDown(KeyCode.At)) { return KeyCode.At; }

        if (Input.GetKeyDown(KeyCode.LeftBracket)) { return KeyCode.LeftBracket; }

        if (Input.GetKeyDown(KeyCode.Backslash)) { return KeyCode.Backslash; }

        if (Input.GetKeyDown(KeyCode.RightBracket)) { return KeyCode.RightBracket; }

        if (Input.GetKeyDown(KeyCode.Caret)) { return KeyCode.Caret; }

        if (Input.GetKeyDown(KeyCode.Underscore)) { return KeyCode.Underscore; }

        if (Input.GetKeyDown(KeyCode.BackQuote)) { return KeyCode.BackQuote; }

        if (Input.GetKeyDown(KeyCode.A)) { return KeyCode.A; }

        if (Input.GetKeyDown(KeyCode.B)) { return KeyCode.B; }

        if (Input.GetKeyDown(KeyCode.C)) { return KeyCode.C; }

        if (Input.GetKeyDown(KeyCode.D)) { return KeyCode.D; }

        if (Input.GetKeyDown(KeyCode.E)) { return KeyCode.E; }

        if (Input.GetKeyDown(KeyCode.F)) { return KeyCode.F; }

        if (Input.GetKeyDown(KeyCode.G)) { return KeyCode.G; }

        if (Input.GetKeyDown(KeyCode.H)) { return KeyCode.H; }

        if (Input.GetKeyDown(KeyCode.I)) { return KeyCode.I; }

        if (Input.GetKeyDown(KeyCode.J)) { return KeyCode.J; }

        if (Input.GetKeyDown(KeyCode.K)) { return KeyCode.K; }

        if (Input.GetKeyDown(KeyCode.L)) { return KeyCode.L; }

        if (Input.GetKeyDown(KeyCode.M)) { return KeyCode.M; }

        if (Input.GetKeyDown(KeyCode.N)) { return KeyCode.N; }

        if (Input.GetKeyDown(KeyCode.O)) { return KeyCode.O; }

        if (Input.GetKeyDown(KeyCode.P)) { return KeyCode.P; }

        if (Input.GetKeyDown(KeyCode.Q)) { return KeyCode.Q; }

        if (Input.GetKeyDown(KeyCode.R)) { return KeyCode.R; }

        if (Input.GetKeyDown(KeyCode.S)) { return KeyCode.S; }

        if (Input.GetKeyDown(KeyCode.T)) { return KeyCode.T; }

        if (Input.GetKeyDown(KeyCode.U)) { return KeyCode.U; }

        if (Input.GetKeyDown(KeyCode.V)) { return KeyCode.V; }

        if (Input.GetKeyDown(KeyCode.W)) { return KeyCode.W; }

        if (Input.GetKeyDown(KeyCode.X)) { return KeyCode.X; }

        if (Input.GetKeyDown(KeyCode.Y)) { return KeyCode.Y; }

        if (Input.GetKeyDown(KeyCode.Z)) { return KeyCode.Z; }

        /*if (Input.GetKeyDown(KeyCode.LeftCurlyBracket)) { return KeyCode.LeftCurlyBracket; }

        if (Input.GetKeyDown(KeyCode.Pipe)) { return KeyCode.Pipe; }

        if (Input.GetKeyDown(KeyCode.RightCurlyBracket)) { return KeyCode.RightCurlyBracket; }

        if (Input.GetKeyDown(KeyCode.Tilde)) { return KeyCode.Tilde; }*/

        if (Input.GetKeyDown(KeyCode.Numlock)) { return KeyCode.Numlock; }

        if (Input.GetKeyDown(KeyCode.CapsLock)) { return KeyCode.CapsLock; }

        if (Input.GetKeyDown(KeyCode.ScrollLock)) { return KeyCode.ScrollLock; }

        if (Input.GetKeyDown(KeyCode.RightShift)) { return KeyCode.RightShift; }

        if (Input.GetKeyDown(KeyCode.LeftShift)) { return KeyCode.LeftShift; }

        if (Input.GetKeyDown(KeyCode.RightControl)) { return KeyCode.RightControl; }

        if (Input.GetKeyDown(KeyCode.LeftControl)) { return KeyCode.LeftControl; }

        if (Input.GetKeyDown(KeyCode.RightAlt)) { return KeyCode.RightAlt; }

        if (Input.GetKeyDown(KeyCode.LeftAlt)) { return KeyCode.LeftAlt; }

        if (Input.GetKeyDown(KeyCode.LeftCommand)) { return KeyCode.LeftCommand; }

        if (Input.GetKeyDown(KeyCode.LeftApple)) { return KeyCode.LeftApple; }

        if (Input.GetKeyDown(KeyCode.LeftWindows)) { return KeyCode.LeftWindows; }

        if (Input.GetKeyDown(KeyCode.RightCommand)) { return KeyCode.RightCommand; }

        if (Input.GetKeyDown(KeyCode.RightApple)) { return KeyCode.RightApple; }

        if (Input.GetKeyDown(KeyCode.RightWindows)) { return KeyCode.RightWindows; }

        if (Input.GetKeyDown(KeyCode.AltGr)) { return KeyCode.AltGr; }

        if (Input.GetKeyDown(KeyCode.Help)) { return KeyCode.Help; }

        if (Input.GetKeyDown(KeyCode.Print)) { return KeyCode.Print; }

        if (Input.GetKeyDown(KeyCode.SysReq)) { return KeyCode.SysReq; }

        if (Input.GetKeyDown(KeyCode.Break)) { return KeyCode.Break; }

        if (Input.GetKeyDown(KeyCode.Menu)) { return KeyCode.Menu; }

        if (Input.GetKeyDown(KeyCode.Mouse0)) { return KeyCode.Mouse0; }

        if (Input.GetKeyDown(KeyCode.Mouse1)) { return KeyCode.Mouse1; }

        if (Input.GetKeyDown(KeyCode.Mouse2)) { return KeyCode.Mouse2; }

        if (Input.GetKeyDown(KeyCode.Mouse3)) { return KeyCode.Mouse3; }

        if (Input.GetKeyDown(KeyCode.Mouse4)) { return KeyCode.Mouse4; }

        if (Input.GetKeyDown(KeyCode.Mouse5)) { return KeyCode.Mouse5; }

        if (Input.GetKeyDown(KeyCode.Mouse6)) { return KeyCode.Mouse6; }

        if (Input.GetKeyDown(KeyCode.JoystickButton0)) { return KeyCode.JoystickButton0; }

        if (Input.GetKeyDown(KeyCode.JoystickButton1)) { return KeyCode.JoystickButton1; }

        if (Input.GetKeyDown(KeyCode.JoystickButton2)) { return KeyCode.JoystickButton2; }

        if (Input.GetKeyDown(KeyCode.JoystickButton3)) { return KeyCode.JoystickButton3; }

        if (Input.GetKeyDown(KeyCode.JoystickButton4)) { return KeyCode.JoystickButton4; }

        if (Input.GetKeyDown(KeyCode.JoystickButton5)) { return KeyCode.JoystickButton5; }

        if (Input.GetKeyDown(KeyCode.JoystickButton6)) { return KeyCode.JoystickButton6; }

        if (Input.GetKeyDown(KeyCode.JoystickButton7)) { return KeyCode.JoystickButton7; }

        if (Input.GetKeyDown(KeyCode.JoystickButton8)) { return KeyCode.JoystickButton8; }

        if (Input.GetKeyDown(KeyCode.JoystickButton9)) { return KeyCode.JoystickButton9; }

        if (Input.GetKeyDown(KeyCode.JoystickButton10)) { return KeyCode.JoystickButton10; }

        if (Input.GetKeyDown(KeyCode.JoystickButton11)) { return KeyCode.JoystickButton11; }

        if (Input.GetKeyDown(KeyCode.JoystickButton12)) { return KeyCode.JoystickButton12; }

        if (Input.GetKeyDown(KeyCode.JoystickButton13)) { return KeyCode.JoystickButton13; }

        if (Input.GetKeyDown(KeyCode.JoystickButton14)) { return KeyCode.JoystickButton14; }

        if (Input.GetKeyDown(KeyCode.JoystickButton15)) { return KeyCode.JoystickButton15; }

        if (Input.GetKeyDown(KeyCode.JoystickButton16)) { return KeyCode.JoystickButton16; }

        if (Input.GetKeyDown(KeyCode.JoystickButton17)) { return KeyCode.JoystickButton17; }

        if (Input.GetKeyDown(KeyCode.JoystickButton18)) { return KeyCode.JoystickButton18; }

        if (Input.GetKeyDown(KeyCode.JoystickButton19)) { return KeyCode.JoystickButton19; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0)) { return KeyCode.Joystick1Button0; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1)) { return KeyCode.Joystick1Button1; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button2)) { return KeyCode.Joystick1Button2; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button3)) { return KeyCode.Joystick1Button3; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button4)) { return KeyCode.Joystick1Button4; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button5)) { return KeyCode.Joystick1Button5; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button6)) { return KeyCode.Joystick1Button6; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button7)) { return KeyCode.Joystick1Button7; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button8)) { return KeyCode.Joystick1Button8; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button9)) { return KeyCode.Joystick1Button9; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button10)) { return KeyCode.Joystick1Button10; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button11)) { return KeyCode.Joystick1Button11; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button12)) { return KeyCode.Joystick1Button12; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button13)) { return KeyCode.Joystick1Button13; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button14)) { return KeyCode.Joystick1Button14; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button15)) { return KeyCode.Joystick1Button15; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button16)) { return KeyCode.Joystick1Button16; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button17)) { return KeyCode.Joystick1Button17; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button18)) { return KeyCode.Joystick1Button18; }

        if (Input.GetKeyDown(KeyCode.Joystick1Button19)) { return KeyCode.Joystick1Button19; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button0)) { return KeyCode.Joystick2Button0; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button1)) { return KeyCode.Joystick2Button1; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button2)) { return KeyCode.Joystick2Button2; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button3)) { return KeyCode.Joystick2Button3; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button4)) { return KeyCode.Joystick2Button4; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button5)) { return KeyCode.Joystick2Button5; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button6)) { return KeyCode.Joystick2Button6; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button7)) { return KeyCode.Joystick2Button7; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button8)) { return KeyCode.Joystick2Button8; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button9)) { return KeyCode.Joystick2Button9; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button10)) { return KeyCode.Joystick2Button10; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button11)) { return KeyCode.Joystick2Button11; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button12)) { return KeyCode.Joystick2Button12; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button13)) { return KeyCode.Joystick2Button13; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button14)) { return KeyCode.Joystick2Button14; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button15)) { return KeyCode.Joystick2Button15; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button16)) { return KeyCode.Joystick2Button16; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button17)) { return KeyCode.Joystick2Button17; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button18)) { return KeyCode.Joystick2Button18; }

        if (Input.GetKeyDown(KeyCode.Joystick2Button19)) { return KeyCode.Joystick2Button19; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button0)) { return KeyCode.Joystick3Button0; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button1)) { return KeyCode.Joystick3Button1; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button2)) { return KeyCode.Joystick3Button2; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button3)) { return KeyCode.Joystick3Button3; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button4)) { return KeyCode.Joystick3Button4; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button5)) { return KeyCode.Joystick3Button5; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button6)) { return KeyCode.Joystick3Button6; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button7)) { return KeyCode.Joystick3Button7; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button8)) { return KeyCode.Joystick3Button8; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button9)) { return KeyCode.Joystick3Button9; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button10)) { return KeyCode.Joystick3Button10; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button11)) { return KeyCode.Joystick3Button11; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button12)) { return KeyCode.Joystick3Button12; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button13)) { return KeyCode.Joystick3Button13; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button14)) { return KeyCode.Joystick3Button14; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button15)) { return KeyCode.Joystick3Button15; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button16)) { return KeyCode.Joystick3Button16; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button17)) { return KeyCode.Joystick3Button17; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button18)) { return KeyCode.Joystick3Button18; }

        if (Input.GetKeyDown(KeyCode.Joystick3Button19)) { return KeyCode.Joystick3Button19; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button0)) { return KeyCode.Joystick4Button0; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button1)) { return KeyCode.Joystick4Button1; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button2)) { return KeyCode.Joystick4Button2; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button3)) { return KeyCode.Joystick4Button3; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button4)) { return KeyCode.Joystick4Button4; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button5)) { return KeyCode.Joystick4Button5; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button6)) { return KeyCode.Joystick4Button6; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button7)) { return KeyCode.Joystick4Button7; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button8)) { return KeyCode.Joystick4Button8; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button9)) { return KeyCode.Joystick4Button9; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button10)) { return KeyCode.Joystick4Button10; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button11)) { return KeyCode.Joystick4Button11; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button12)) { return KeyCode.Joystick4Button12; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button13)) { return KeyCode.Joystick4Button13; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button14)) { return KeyCode.Joystick4Button14; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button15)) { return KeyCode.Joystick4Button15; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button16)) { return KeyCode.Joystick4Button16; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button17)) { return KeyCode.Joystick4Button17; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button18)) { return KeyCode.Joystick4Button18; }

        if (Input.GetKeyDown(KeyCode.Joystick4Button19)) { return KeyCode.Joystick4Button19; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button0)) { return KeyCode.Joystick5Button0; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button1)) { return KeyCode.Joystick5Button1; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button2)) { return KeyCode.Joystick5Button2; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button3)) { return KeyCode.Joystick5Button3; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button4)) { return KeyCode.Joystick5Button4; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button5)) { return KeyCode.Joystick5Button5; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button6)) { return KeyCode.Joystick5Button6; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button7)) { return KeyCode.Joystick5Button7; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button8)) { return KeyCode.Joystick5Button8; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button9)) { return KeyCode.Joystick5Button9; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button10)) { return KeyCode.Joystick5Button10; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button11)) { return KeyCode.Joystick5Button11; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button12)) { return KeyCode.Joystick5Button12; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button13)) { return KeyCode.Joystick5Button13; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button14)) { return KeyCode.Joystick5Button14; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button15)) { return KeyCode.Joystick5Button15; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button16)) { return KeyCode.Joystick5Button16; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button17)) { return KeyCode.Joystick5Button17; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button18)) { return KeyCode.Joystick5Button18; }

        if (Input.GetKeyDown(KeyCode.Joystick5Button19)) { return KeyCode.Joystick5Button19; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button0)) { return KeyCode.Joystick6Button0; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button1)) { return KeyCode.Joystick6Button1; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button2)) { return KeyCode.Joystick6Button2; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button3)) { return KeyCode.Joystick6Button3; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button4)) { return KeyCode.Joystick6Button4; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button5)) { return KeyCode.Joystick6Button5; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button6)) { return KeyCode.Joystick6Button6; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button7)) { return KeyCode.Joystick6Button7; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button8)) { return KeyCode.Joystick6Button8; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button9)) { return KeyCode.Joystick6Button9; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button10)) { return KeyCode.Joystick6Button10; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button11)) { return KeyCode.Joystick6Button11; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button12)) { return KeyCode.Joystick6Button12; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button13)) { return KeyCode.Joystick6Button13; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button14)) { return KeyCode.Joystick6Button14; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button15)) { return KeyCode.Joystick6Button15; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button16)) { return KeyCode.Joystick6Button16; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button17)) { return KeyCode.Joystick6Button17; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button18)) { return KeyCode.Joystick6Button18; }

        if (Input.GetKeyDown(KeyCode.Joystick6Button19)) { return KeyCode.Joystick6Button19; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button0)) { return KeyCode.Joystick7Button0; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button1)) { return KeyCode.Joystick7Button1; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button2)) { return KeyCode.Joystick7Button2; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button3)) { return KeyCode.Joystick7Button3; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button4)) { return KeyCode.Joystick7Button4; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button5)) { return KeyCode.Joystick7Button5; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button6)) { return KeyCode.Joystick7Button6; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button7)) { return KeyCode.Joystick7Button7; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button8)) { return KeyCode.Joystick7Button8; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button9)) { return KeyCode.Joystick7Button9; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button10)) { return KeyCode.Joystick7Button10; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button11)) { return KeyCode.Joystick7Button11; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button12)) { return KeyCode.Joystick7Button12; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button13)) { return KeyCode.Joystick7Button13; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button14)) { return KeyCode.Joystick7Button14; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button15)) { return KeyCode.Joystick7Button15; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button16)) { return KeyCode.Joystick7Button16; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button17)) { return KeyCode.Joystick7Button17; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button18)) { return KeyCode.Joystick7Button18; }

        if (Input.GetKeyDown(KeyCode.Joystick7Button19)) { return KeyCode.Joystick7Button19; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button0)) { return KeyCode.Joystick8Button0; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button1)) { return KeyCode.Joystick8Button1; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button2)) { return KeyCode.Joystick8Button2; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button3)) { return KeyCode.Joystick8Button3; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button4)) { return KeyCode.Joystick8Button4; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button5)) { return KeyCode.Joystick8Button5; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button6)) { return KeyCode.Joystick8Button6; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button7)) { return KeyCode.Joystick8Button7; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button8)) { return KeyCode.Joystick8Button8; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button9)) { return KeyCode.Joystick8Button9; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button10)) { return KeyCode.Joystick8Button10; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button11)) { return KeyCode.Joystick8Button11; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button12)) { return KeyCode.Joystick8Button12; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button13)) { return KeyCode.Joystick8Button13; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button14)) { return KeyCode.Joystick8Button14; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button15)) { return KeyCode.Joystick8Button15; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button16)) { return KeyCode.Joystick8Button16; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button17)) { return KeyCode.Joystick8Button17; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button18)) { return KeyCode.Joystick8Button18; }

        if (Input.GetKeyDown(KeyCode.Joystick8Button19)) { return KeyCode.Joystick8Button19; }

        return KeyCode.None;
    }
}
