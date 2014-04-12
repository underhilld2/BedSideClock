using System;

namespace SharedLogicLibrary.Logic
{
  public interface IClockTimer
  {
    System.DateTime CurrentDateTime { get; }
  }
}