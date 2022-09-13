using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    // C# auto-propeties that is publicly accesssible but can only set privately; 
    public Transform target { get;  }
    public Vector3 StartPos { get;  }
    public Vector3 EndPos { get;  }
    public float StartTime { get;  }
    public float Duration { get;  }
}
