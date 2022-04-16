using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public class EffectBuilder
    {
        private readonly List<IEffect> _effects = new List<IEffect>();
        private readonly List<IEnumerator> _activeRoutines = new List<IEnumerator>();
        private readonly MonoBehaviour behaviour;

        private event Action action = delegate { };

        public EffectBuilder(MonoBehaviour behaviour)
        {
            this.behaviour = behaviour;
        }

        public EffectBuilder AddEffect(IEffect effect)
        {
            _effects.Add(effect);
            return this;
        }

        public void ExecuteEffects()
        {
            _activeRoutines.ForEach(routine => behaviour.StopCoroutine(routine));
            _activeRoutines.Clear();
            _effects.ForEach(effect => {
                IEnumerator routine = effect.Execute();
                _activeRoutines.Add(routine);
                behaviour.StartCoroutine(routine);
            });
        }
    } 
}
