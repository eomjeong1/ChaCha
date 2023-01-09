using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticker
{
    public string stickerName;
    public string stickerSound;
    public bool isCheck;

    public Sticker(string stickerName, string stickerSound, bool isCheck)
    {
        this.stickerName = stickerName;
        this.stickerSound = stickerSound;
        this.isCheck = isCheck;
    }
}
