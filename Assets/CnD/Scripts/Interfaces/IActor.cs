using System;
using UnityEngine;

namespace CnD.Scripts.Interfaces
{
    public interface IActor
    {
        void Die();
        void TakeDamage(int damageReceived);
    }
}