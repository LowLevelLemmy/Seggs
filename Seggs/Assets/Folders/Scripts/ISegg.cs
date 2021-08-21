using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ISegg
{
    UnityEvent GetSuccessEvent();
    UnityEvent GetFailureEvent();
    float transitionSpeed { get; set; }

}
