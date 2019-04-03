﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class MLP
    {
        readonly int n_input;
        readonly int n_hidden;
        readonly int n_output;
        readonly double learning_rate = 0.2;

        List<Perceptron> m_inputs_layer = new List<Perceptron>();
        List<float> m_weight_layer_1 = new List<float>();
        List<Perceptron> m_hidden_layer = new List<Perceptron>();
        List<float> m_weight_layer_2 = new List<float>();
        List<Perceptron> m_output_layer = new List<Perceptron>();
        public float m_out;

        /// <summary>
        /// Multilayer perceptron constructor
        /// </summary>
        public MLP(int n_in, int n_h, int n_out)
        {
            n_input = n_in;
            n_hidden = n_h;
            n_output = n_out;

            //Populate lists for input, hidden, and output layers
            for (byte i = 0; i < n_input; i++)
            {
                m_inputs_layer.Add(new Perceptron(1, learning_rate));
            }
            for (byte i = 0; i < n_hidden; i++)
            {
                m_hidden_layer.Add(new Perceptron(n_input, learning_rate));
            }
            for (byte i = 0; i < n_output; i++)
            {
                m_output_layer.Add(new Perceptron(n_hidden, learning_rate));
            }
        }

        public void GenerateOutput()
        {
            for (byte i = 0; i < n_hidden; i++)
            {
                m_hidden_layer[i].Sum();
            }
            for (byte i = 0; i < n_output; i++)
            {
                m_output_layer[i].Sum();
            }
            m_out = m_output_layer[0].GetOutput();   
        }

        /// <summary>
        /// Adds value in the input layer at the
        /// index specified
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void AddInput(int index, float value)
        {
            m_inputs_layer[index].SetInput(0, value);
        }
    }
}